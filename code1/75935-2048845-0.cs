    using System;
    using Microsoft.Office.Interop.Excel
    using VBA = Microsoft.Vbe.Interop;
    ...
    VBA.Forms.UserForm form;
    VBA.Forms.Control c;
    foreach (VBA.VBComponent mod in wb.VBProject.VBComponents)
    {
        // Use only VBA Forms
        if (!(mod.Designer is VBA.Forms.UserForm)) continue;
        form = (VBA.Forms.UserForm) mod.Designer;
        for (int i = 1; i < form.Controls.Count; i++)
        {
            c = (VBA.Forms.Control)form.Controls.Item(i);
            ...
        }
    }
