    class Program
    {
        static void Main(string[] args)
        {
            //Length depends on your Vector<int>.Count. In my computer it is 4
            Vector<int> vector1 = new Vector<int>(4); //vector1 == {<4, 4, 4, 4>}
            Vector<int> vector2 = new Vector<int>(5); //vector2 == {<5, 5, 5, 5>}
            Vector<int> mask = Vector.GreaterThan(vector1, vector2); //mask == {<0, 0, 0, 0>}
            Vector<int> selected = Vector.ConditionalSelect(mask, vector1, vector2); //selected == {<5, 5, 5, 5>}
            vector1 = new Vector<int>(4); //vector1 == {<4, 4, 4, 4>}
            vector2 = new Vector<int>(3); //vector2 == {<3, 3, 3, 3>}
            mask = Vector.GreaterThan(vector1, vector2); //mask == {<-1, -1, -1, -1>}
            selected = Vector.ConditionalSelect(mask, vector1, vector2); //selected == {<4, 4, 4, 4>}
            mask = new Vector<int>(123); //mask == {<123, 123, 123, 123>}
            selected = Vector.ConditionalSelect(mask, vector1, vector2); //selected == {<0, 0, 0, 0>}
            mask = new Vector<int>(4);
            selected = Vector.ConditionalSelect(mask, vector1, vector2); //selected == {<7, 7, 7, 7>}
        }
    }
