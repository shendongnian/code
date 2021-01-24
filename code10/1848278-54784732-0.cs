     Label label = new Label() {
         Name = "lbl" + mc.FirstName
     };
     Binding binding = new Binding()
     {
          Mode = BindingMode.TwoWay,
          UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
          Path = new PropertyPath("FirstName")
     };
     label.SetBinding(ContentProperty, binding);
