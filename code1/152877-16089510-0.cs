        using System.Collections.Generic;
      using System.Linq;
       using System.Text;
     using System.Threading.Tasks;
     //the next 2 using's had to be downloaded and "Add Reference"d for Visual Studio Express 2012
     using Microsoft.AnalysisServices;
     using Microsoft.AnalysisServices.AdomdClient;
     using System.Windows.Forms;
     using System;
     using System.Data;
     using System.Drawing;
     namespace SSASDataview
     {
             partial class Form1
       {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void RunSSAS(object sender, EventArgs e)
        {
            //i don't think  Dataset is in the Analysis Services directives
            DataSet ds = new DataSet();
            // provider is the constant olap.  datasource is the same server name you provide for Mgmt Studio or localhost
            // initial catalog is tricky and important.  It is not a standard ms sql database you see in Management Studio,
            // even if your cube was create with tables from a particular database.
            // the only place I was able to see "initial catalog" value was a File -> Open -> Analysis Services Database in 2012 Management Studio
            // it was also the name of the VS2010 solution I used to create the cube.
            AdomdConnection myconnect = new AdomdConnection(@"provider=olap;initial catalog=GLCubeThree;datasource=localhost");
            AdomdDataAdapter mycommand = new AdomdDataAdapter();
            mycommand.SelectCommand = new AdomdCommand();
            mycommand.SelectCommand.Connection = myconnect;
            // this query was created by the "Browser" you see for an Analysis Services project 
            // if you poke around the icons on the browser table the Design Mode icon will give you the cube query
            // I think it's an MDX query, threre are also xml queries you can run with adomd
            mycommand.SelectCommand.CommandText = "SELECT NON EMPTY { [Measures].[Per Balance] } ON COLUMNS, NON EMPTY { ([Gltime].[Fisc Per].[Fisc Per].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Gltime].[Fisc Per].&[201301], [Gltime].[Fisc Per].&[201302], [Gltime].[Fisc Per].&[201307] } ) ON COLUMNS FROM [GL Cube]) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";
            myconnect.Open();
            mycommand.Fill(ds, "tbl");
            myconnect.Close();
            // the below assigns the results of the cube query to a dataGridView
            // if you drag a dataGridView control to your pallete it will create exactly
            // what you need for the line below to work.
            // your project type has to be a Window Forms Applications
            // this code shown here is in the default Form1.Designer.cs not Form1.cs
            dataGridView1.DataSource = new DataView(ds.Tables[0]);
            
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button runssas;
        private System.Windows.Forms.Button quit;
    }
}
