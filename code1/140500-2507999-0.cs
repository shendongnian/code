    interface IHasInstellingen {
        Instellingen Instellingen { get; }
    }
    public class Class1: Label, IHasInstellingen {
        public Instellingen Instellingen { get; private set; }
    }
    public class Class2: Button, IHasInstellingen {
        public Instellingen Instellingen { get; private set; }
    }
    private void GetInstellingenFromClass(IHasInstellingen c) {
        Instellingen ig = c.Instellingen;
        //Do things...
    }
    //Alternatively:
    private void GetInstellingenFromClass(Control c) {
        IHasInstellingen hi = c as IHasInstellingen;
        if (hi == null)
            return;     //Or throw an ArgumentException
        Instellingen ig = hi.Instellingen;
        //Do things...
    }
