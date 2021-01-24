`
using System.ComponentModel;
using System.ComponentModel.Design;
[EditorAttribute(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
public string FalseText
{
...
}
[EditorAttribute(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
public string TrueText
{
...
}
`
Be sure to add `System.Design` and `System.Drawing` as references to your project.
