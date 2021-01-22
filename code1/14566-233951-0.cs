         string filename = @"C:\Users\gurdip.sira\Documents\Visual Studio 2008\WebSites\Supressions\APP_DATA\surpressionstest.csv";//1
         StreamWriter sWriter = new StreamWriter(filename);//2
         string Str = string.Empty;//3
         string headertext = ""; //4
         sWriter.WriteLine(headertext);  //5
         for (int i = 0; i <= (this.GridView3.Rows.Count - 1); i++)   //6
         {         //7
            for (int j = 0; j <= (this.GridView3.Columns.Count - 1); j++)  //8
            { //9
                   Str = this.GridView3.Rows[i].Cells[j].Text.ToString();//10
                   sWriter.Write(Str);//11
            }//12
            sWriter.WriteLine();//13
          }//14
          sWriter.Close();//15
    }//16
