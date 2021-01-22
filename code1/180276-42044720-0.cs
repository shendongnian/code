    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    
    namespace MyCustomControls
    {
        public sealed class ReadOnlyPropertyGrid : System.Windows.Forms.PropertyGrid
        {
            #region Non-greyed read only support
            public ReadOnlyPropertyGrid()
            {
                this.ViewForeColor = Color.FromArgb(1, 0, 0);
            }
            //---
            private bool _readOnly;
            public bool ReadOnly
            {
                get { return _readOnly; }
                set
                {
                    _readOnly = value;
                    this.SetObjectAsReadOnly(this.SelectedObject, _readOnly);
                }
            }
            //---
            protected override void OnSelectedObjectsChanged(EventArgs e)
            {
                this.SetObjectAsReadOnly(this.SelectedObject, this._readOnly);
                base.OnSelectedObjectsChanged(e);
            }
            //---
            private void SetObjectAsReadOnly(object selectedObject, bool isReadOnly)
            {
                if (this.SelectedObject != null)
                {
                    TypeDescriptor.AddAttributes(this.SelectedObject, new Attribute[] { new ReadOnlyAttribute(_readOnly) });
                    this.Refresh();
                }
            }
            //---
            #endregion
        }
    }
