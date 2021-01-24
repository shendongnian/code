        public void TestMethod1 ( )
        {
            List<Model> listmodel = new List<Model>( )
            {
                new Model() { Prop1 = "one", Prop2 = 2 },
                new Model() { Prop1 = "one", Prop2 = 6 },
                new Model() { Prop1 = "two", Prop2 = 1 },
                new Model() { Prop1 = "three", Prop2 = 7 },
                new Model() { Prop1 = "four", Prop2 = 6 },
            };
            var output = listmodel.Distinct(  ).ToList( );
            output.ToList( ).ForEach( x => Console.WriteLine( x.ToString( ) ) );
        }
        public class Model
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public string Prop3 { get; set; }
            public string Prop4 { get; set; }
            public override bool Equals ( object obj )
            {
                Model casted = obj as Model;
                if (casted == null) return false; //If cast an object to my model is null, is not my model and is not equal
                if (casted.Prop1 == this.Prop1) return true; //My logic define if the input.Prop1 is equal to my Prop1, this is equal
                return false;
            }
            public override int GetHashCode ( )
            {
                return 1;
            }
            public override string ToString ( )
            {
                return $"{this.Prop1} - {this.Prop2} - {this.Prop3} - {this.Prop4}";
            }
        }
