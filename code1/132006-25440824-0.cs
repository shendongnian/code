     // Get the Product Name from the Assembly information
     string productName = String.Empty;
     var list = Application.Current.MainWindow.GetType().Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), true);
     if (list != null)
     {
       if (list.Length > 0)
       {
         productName = (list[0] as AssemblyProductAttribute).Product;
       }
     }
