        Func<uint, ButtonPressEventHandler> indexWrapper = ((index) => ((s, e) => { AddButtonPressed_wrapped(s, e, index); }));   
        ...
        plus[i].ButtonPressEvent += indexWrapper(i);
         
        ...
        protected virtual void AddButtonPressed_wrapped(object sender, EventArgs e, uint index)
        {
          Console.WriteLine("Button pressed");
          Console.WriteLine("Index = {0}", index);
        }
