    public class GeometryPointTypeHandler : SqlMapper.TypeHandler<GeometryPoint>
    {
        //      POINT(X Y)
        //      POINT(X Y Z M)
        public override GeometryPoint Parse(object value)
        {
            if (value == null)
                return null;
            if (!Regex.IsMatch(value.ToString(), @"^(POINT \()(.+)(\))"))
                throw new Exception("Value is not a Geometry Point");
            //Get values inside the brackets
            string geometryPoints = value.ToString().Split('(', ')')[1];
            //Split values by empty space
            string[] geometryValues = geometryPoints.Split(' ');
            double x = this.ConvertToDouble(geometryValues[0]);
            double y = this.ConvertToDouble(geometryValues[1]);
            double? z = null;
            if (geometryValues.Length >= 3)
                z = this.ConvertToDouble(geometryValues[2]);
            double? m = null;
            if (geometryValues.Length >= 4)
                m = this.ConvertToDouble(geometryValues[3]);
            return GeometryPoint.Create(x, y, z, m);
        }
        public override void SetValue(IDbDataParameter parameter, GeometryPoint value)
        {
            throw new NotImplementedException();
        }
        private double ConvertToDouble(string value)
        {
            return double.Parse(value, CultureInfo.InvariantCulture);
        }
    }
