    private void SymbolView_OnDrop(object sender, DragEventArgs e)
        {
            Point pos = e.GetPosition(SymbolViewControl);
            Console.WriteLine(e.Data.GetData("Object").ToString());
            SymbolModel obj = (SymbolModel) e.Data.GetData("Object");
            Type t = obj.GetType();
            var symbol = (SymbolModel)Activator.CreateInstance(t);
            symbol.CanvasTopImage = pos.Y;
            symbol.CanvasLeftImage = pos.X;
            _symbolViewModel.Symbols.Add(symbol);
        }
