    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace sandbox
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        }
    
        class Student
        {
            string studentFirstMiddleLastName;
            IList<double> allStudentGrades = new List<double>();
    
            public Student(string studentFirstMiddleLastName, IList<double> allStudentGrades)
            {
                StudentFirstMiddleLastName = studentFirstMiddleLastName;
                AllStudentGrades = allStudentGrades;
            }
    
            public string StudentFirstMiddleLastName { get => studentFirstMiddleLastName; set => studentFirstMiddleLastName = value; }
            public IList<double> AllStudentGrades { get => allStudentGrades; set => allStudentGrades = value; }
    
            public double CalculateAverageofAllStudentGrades()
            {
                double average = 0.0;
    
                // add up all grades in AllStudentGrades, divide by number of items in AllStudentGrades, load result of this calculation into the variable `average`
    
                return average;
            }
        }
    }
