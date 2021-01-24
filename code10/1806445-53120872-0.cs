    using System.Linq;
    ...
    foreach (Button btn in this.Controls.OfType<Button>()) 
    {
        btn.UseVisualStyleBackColor = true;
        btn.BackColor = Control.DefaultBackColor;
    }
