    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace MyWpfApp
    {
      public partial class ModDatePicker : UserControl
      {
        public DateTime? SelectedDate
        {
          get => (DateTime?)GetValue(SelectedDateProperty);
          set
          {
            this.DatePicker.SelectedDate = value;
            SetValue(SelectedDateProperty, value);
          }
        }
    
        public static readonly DependencyProperty SelectedDateProperty =
          DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(ModDatePicker), new PropertyMetadata(null));
    
        public DateTime? DisplayDateEnd
        {
          get => (DateTime?)GetValue(DisplayDateEndProperty);
          set
          {
            this.DatePicker.DisplayDateEnd = value;
            SetValue(DisplayDateEndProperty, value);
          }
        }
    
        public static readonly DependencyProperty DisplayDateEndProperty =
          DependencyProperty.Register("DisplayDateEnd", typeof(DateTime?), typeof(ModDatePicker), new PropertyMetadata(new DateTime(2006,5,1)));
    
        public ModDatePicker()
        {
          InitializeComponent();
        }
      }
    }
