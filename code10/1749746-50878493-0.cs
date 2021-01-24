    var app = Application;
    var exp = app.ActiveExplorer();
    CommandBar cb = exp.CommandBars.Add("RubberduckCallbackProxy", Temporary: true);
    CommandBarControl btn = cb.Controls.Add(MsoControlType.msoControlButton, 1);
    btn.OnAction = declaration.QualifiedName.ToString();
    btn.Execute();
    cb.Delete();
