    //using System.Linq;
    var list = this.Controls.OfType<Label>().Where
    ( 
        label => name.Contains("label")           //Use these, or any other
              && label.Tag == "MyUniqueTag"       //properties, to find what you need
    );
    foreach (var label in list)
    {
        DoSomething(label);
    }
