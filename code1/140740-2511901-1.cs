    foreach(String item in stringKeyCollection){
       //create the base column (use whatever column type you want
       DataGridBoundColumn column = new DataGridBoundColumn();
       //create the binding for the column
       column.Binding = new Binding("[" + item + "]");
       //set the header
       column.Header = item;
    }
