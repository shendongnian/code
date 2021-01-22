    using System;    
    using System.Collections.Generic;    
    using System.ComponentModel;    
    using System.Data;    
    using System.Drawing;    
    using System.Linq;    
    using System.Text;    
    using System.Windows.Forms;    
    using Word = Microsoft.Office.Interop.Word;
     
    
    namespace WordAddIn3
    {
    
       public partial class Form1 : Form
       {
    
          public Form1()
          {
    
               InitializeComponent();
    
          }
    
          private void button1_Click(object sender, EventArgs e)
          {
    
              Word.Application wdApp = Globals.ThisAddIn.Application;
              Word.Document doc = wdApp.ActiveDocument;
    
              string fileName = "c:\\testimage.jpg"; //the picture file to be inserted
    
              Object oMissed = doc.Paragraphs[1].Range; //the position you want to insert
              Object oLinkToFile = false; //default
              Object oSaveWithDocument = true;//default   
    
          doc.InlineShapes.AddPicture(fileName, ref oLinkToFile, ref oSaveWithDocument, ref oMissed);
          }
    
       }
    
  
    }
