    class Program
    {
        static void Main(string[] args)
        {
            EncodingCharacters enchars = new EncodingCharacters('|', "^~\\&");
            IModelClassFactory theFactory = new DefaultModelClassFactory();
    
            NHapi.Model.V251.Segment.RXA rxa = new NHapi.Model.V251.Segment.RXA(new VXU_V04(theFactory), theFactory);
            IType[] t = rxa.GetSubstanceManufacturerName(0).Components;
            SetRXA(t);
            Debug.Print(PipeParser.Encode(rxa, enchars));
            Console.Read();
        }
    
    
        public static void SetRXA(IType[] components)
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] is IPrimitive)
                {
                    IPrimitive prim = (IPrimitive)components[i];
                    prim.Value = "Component"+i;
                }
                else if (components[i] is IComposite)
                    SetRXA(((IComposite)components[i]).Components);
                //if Varies do something else
            }
        }
    }
