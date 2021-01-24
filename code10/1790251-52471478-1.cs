    var MyList = new List<List<List<List<double[]>>>>
    {//Fill the outer list
         new List<List<List<double[]>>>
         {// Fill one level down
             new List<List<double[]>>
             {// etc
                 new List<double[]>
                 {// and finally fill that bottom most list with a double array
                     new double[]
                     {// With however many elements you want
                        0.0,0.0,0.0,0.0
                     }
                 }
             }
         }
    }
