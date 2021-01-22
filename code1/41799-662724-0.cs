//// Form1 default form
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Winforms_Mef
{
   public interface IForm
   {
      void MoveForm(Form form);
   }
   public partial class Form1 : Form 
   {
      private CompositionContainer _container;
      [Import]
      public IEnumerable<IForm> Forms { get; set; }
      public Form1()
      {
         Compose();
         InitializeComponent();
         foreach (IForm form in Forms)
         {
            this.SuspendLayout();
            this.Controls.Clear(); // wipe out the current version of the form
            this.ResumeLayout(false);
            form.MoveForm(this);
         }
      }
      private void Compose()
      {
         var catalog = new AssemblyCatalog(typeof(IForm).Assembly);
         var batch = new CompositionBatch();
         batch.AddPart(this);
         _container = new CompositionContainer(catalog);
         _container.Compose(batch);
      }
   }
}
//// Form 2 uses Mef to replace Form1
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
namespace Winforms_Mef
{
   [Export(typeof(IForm))]
   public partial class Form2 : Form,IForm
   {
      public Form2()
      {
         InitializeComponent();
      }
      public void MoveForm(Form form)
      {
         this.SuspendLayout();
         form.SuspendLayout();
         form.AutoScaleDimensions = this.AutoScaleDimensions;
         form.AutoScaleMode=this.AutoScaleMode;
         form.ClientSize=this.ClientSize;
         form.Name=this.Name;
         form.Text=this.Text;
         while (this.Controls.Count > 0)
         {
            form.Controls.Add(this.Controls[0]);
         }
         this.ResumeLayout(false);
         form.ResumeLayout(false);
      }
   }
}
