      using SWF = System.Windows.Forms;
      using NUF = NUnit.Framework;
      namespace workshop.findControlTest {
         [NUF.TestFixture]
         public class FormTest {
            [NUF.Test]public void Find_menu() {
               // == prepare ==
               var form = new SWF.Form();
               var menuStrip = new SWF.MenuStrip();
               var fileTool = new SWF.ToolStripMenuItem();
               fileTool.Name = "fileTool";
               fileTool.Text = "File";
               menuStrip.Items.Add(fileTool);
               form.Controls.Add(menuStrip);
      
               // == execute ==
               var ctrl = form.Controls.Find("fileTool", true);
      
               // == not found! ==
               NUF.Assert.That(ctrl.Length, NUF.Is.EqualTo(0)); 
            }
         }
      }
