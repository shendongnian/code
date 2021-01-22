    /*
     * note that in C#, I can refer to the "DesignerAttribute" class within the [ brackets ]
     * by simply "Designer".  The compiler adds the "Attribute" to the end for us (assuming
     * there's no attribute class named simply "Designer").
     */
    [Designer("System.Windows.Forms.Design.ToolStripDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ...(other attributes)]
    public class ToolStrip : ScrollableControl, IArrangedElement, ...(other interfaces){
        ...
    }
