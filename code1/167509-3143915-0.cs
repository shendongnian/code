WebService.IStudentService.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using StudentLib;
    
    namespace WebService
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
        [ServiceContract]
        public interface IStudentService
        {
            [OperationContract]
            StudentLib.Student GetStudentById(Int32 id);
    
            [OperationContract]
            void AddStudent(StudentLib.Student student);
        }
    }
WebService.StudentService.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using StudentLib;
    
    namespace WebService
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
        public class StudentService : IStudentService
        {
            public StudentLib.Student GetStudentById(int id)
            {
                return new StudentLib.Student() { Name = "John Doe", Score = 80, TimeAdded = DateTime.Now, Comment = "Average" };
            }
    
            public void AddStudent(StudentLib.Student student)
            {
                // Code to add student
            }
        }
    }
WebService's Web.Config
    <?xml version="1.0"?>
    <configuration>
      <system.web>
        <compilation debug="true" targetFramework="4.0" />
      </system.web>
      <system.serviceModel>
        <bindings />
        <client />
        <services>
          <service name="WebService.StudentService" behaviorConfiguration="metaDataBehavior">
            <endpoint address="basic" binding="basicHttpBinding" contract="WebService.IStudentService" />
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior name="metaDataBehavior">
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="true"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <serviceHostingEnvironment multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true"/>
      </system.webServer>
    </configuration>
StudentLib.Student.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Runtime.Serialization;
    
    namespace StudentLib
    {
        [DataContract]
        public class Student
        {
            [DataMember]
            public String Name { get; set; }
    
            [DataMember]
            public Int32 Score { get; set; }
    
            [DataMember]
            public DateTime TimeAdded { get; set; }
    
            [DataMember]
            public String Comment { get; set; }
        }
    }
DesktopClient.StudentViewModel.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace DesktopClient
    {
        class StudentViewModel
        {
            protected StudentLib.Student Student { get; set; }
    
            public StudentViewModel(StudentLib.Student student)
            {
                this.Student = student;
            }
    
            public String Name { get { return Student.Name; } }
            public Int32 Score { get { return Student.Score; } }
            public DateTime TimeAdded { get { return Student.TimeAdded; } }
            public String Comment { get { return Student.Comment; } }
        }
    }
DesktopClient.MainWindow.xaml
    <Window x:Class="DesktopClient.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow"
            Width="400"
            Height="300"
            Loaded="Window_Loaded">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
            <TextBlock Grid.Column="0"
                       Grid.Row="0">Name :</TextBlock>
            <TextBlock Grid.Column="1"
                       Grid.Row="0"
                       Text="{Binding Name}"></TextBlock>
            <TextBlock Grid.Column="0"
                       Grid.Row="1">Score :</TextBlock>
            <TextBlock Grid.Column="1"
                       Grid.Row="1"
                       Text="{Binding Score}"></TextBlock>
            <TextBlock Grid.Column="0"
                       Grid.Row="2">Time Added :</TextBlock>
            <TextBlock Grid.Column="1"
                       Grid.Row="2"
                       Text="{Binding TimeAdded}"></TextBlock>
            <TextBlock Grid.Column="0"
                       Grid.Row="3">Comment :</TextBlock>
            <TextBlock Grid.Column="1"
                       Grid.Row="3"
                       Text="{Binding Comment}"></TextBlock>
        </Grid>
    </Window>
DesktopClient.MainWindow.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using DesktopClient.StudentService;
    using StudentLib;
    
    namespace DesktopClient
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                IStudentService client = new StudentServiceClient();
    
                Student student = client.GetStudentById(1);
                DataContext = new StudentViewModel(student);
    
                client.AddStudent(new StudentLib.Student() { Name = "Jane Doe", Score = 70, TimeAdded = DateTime.Now, Comment = "Average" });
            }
        }
    }
