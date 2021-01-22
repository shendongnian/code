    public class HappyClass
    {
        enum TheUnit
        {
            Points,
            Picas,
            Inches
        }
        class MyDistanceClass
        {
            int distance;
            TheUnit units;
            public MyDistanceClass(int theDistance, TheUnit unit)
            {
                distance = theDistance;
                units = unit;
            }
            public static int ConvertDistance(int oldDistance, TheUnit oldUnit, TheUnit newUnit)
            {
                // insert real unit conversion code here :-)
                return oldDistance * 100;
            }
            /// <summary>
            /// Figure out if we are equal distance, converting into the same units of measurement if we have to
            /// </summary>
            /// <param name="obj">the other guy</param>
            /// <returns>true if we are the same distance</returns>
            public override bool Equals(object obj)
            {
                MyDistanceClass other = obj as MyDistanceClass;
                if (other == null) return false;
                if (other.units != this.units)
                {
                    int newDistance = MyDistanceClass.ConvertDistance(other.distance, other.units, this.units);
                    return distance.Equals(newDistance);
                }
                else
                {
                    return distance.Equals(other.distance);
                }
            }
            public override int GetHashCode()
            {
                // even if the distance is equal in spite of the different units, the objects are not
                return distance.GetHashCode() * units.GetHashCode();
            }
        }
        static void Main(string[] args)
        {
            // these are the same distance... 72 points = 1 inch
            MyDistanceClass distPoint = new MyDistanceClass(72, TheUnit.Points);
            MyDistanceClass distInch = new MyDistanceClass(1, TheUnit.Inch);
            Debug.Assert(distPoint.Equals(distInch), "these should be true!");
            Debug.Assert(distPoint.GetHashCode() != distInch.GetHashCode(), "But yet they are fundimentally different values");
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add(new KeyValuePair<MyDistanceClass, object>(distPoint, 1), 1);
            //this should not barf
            dict.Add(new KeyValuePair<MyDistanceClass, object>(distInch, 1), 1);
            return;
        }
    }
