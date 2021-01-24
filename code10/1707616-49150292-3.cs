     private void button1_Click(object sender, EventArgs e)
     {
         var mathFactory = new MathFactory();
         var operation = mathFactory.GetOperatorByType("Add");
         var result = operation.Process(new Input());
    }
