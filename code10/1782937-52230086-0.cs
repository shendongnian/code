    interface IPrintable
    {
         string GetOutput();
    }
    
    class Document : IPrintable
    {
        ...
        public string GetOutput()
        {
            return ...; // final formatted representation
        }
    }
    
    class Printer
    {
        public void Print(IPrintable printable)
        {
            var output = printable.GetOutput();
            ... // print it out
        }
    }
