    [Serializable]
    [OracleCustomTypeMappingAttribute("MDSYS.SDO_GEOMETRY")]
    public class SdoGeometry : IOracleCustomTypeFactory, 
                               IOracleCustomType, 
                               ICloneable, INullable
    {
        #region Variables
        private int _sdoGType;
        private int _sdoSrid;
        private SdoPoint _sdoPoint;
        private SdoElemInfo _sdoElemInfo;
        private SdoOrdinates _sdoOrdinate;
    
        private bool _sdoGTypeIsNull;
        private bool _sdoSridIsNull;
        #endregion
    
        #region Properties
        [OracleObjectMappingAttribute("SDO_GTYPE")]
        public int SdoGType
        {
            get { return _sdoGType; }
            set
            {
                _sdoGType = value;
                _sdoGTypeIsNull = false;
            }
        }
    
        public SdoGeometryType SdoGeometryType
        {
            get { return (Entities.Geometry.SdoGeometryType)(SdoGType % 100); }
        }
    
        public int Dimensions
        {
            get { return (int)(SdoGType / 1000); }
        }
    
        public int LrsDimensions
        {
            get { return (int)((SdoGType / 100) % 10); }
        }
    
        [OracleObjectMappingAttribute("SDO_SRID")]
        public int SdoSrid
        {
            get { return _sdoSrid; }
            set
            {
                _sdoSrid = value;
                _sdoSridIsNull = false;
            }
        }
    
        [OracleObjectMappingAttribute("SDO_POINT")]
        public SdoPoint SdoPoint
        {
            get { return _sdoPoint; }
            set { _sdoPoint = value; }
        }
    
        [OracleObjectMappingAttribute("SDO_ELEM_INFO")]
        public SdoElemInfo SdoElemInfo
        {
            get { return _sdoElemInfo; }
            set { _sdoElemInfo = value; }
        }
    
        [OracleObjectMappingAttribute("SDO_ORDINATES")]
        public SdoOrdinates SdoOrdinates
        {
            get { return _sdoOrdinate; }
            set { _sdoOrdinate = value; }
        }
    
        public static SdoGeometry Null
        {
            get
            {
                SdoGeometry obj = new SdoGeometry();
    
                return obj;
            }
        }
        #endregion
    
        #region Constructors
        public SdoGeometry()
        {
            _sdoGTypeIsNull = true;
            _sdoSridIsNull = true;
            _sdoElemInfo = SdoElemInfo.Null;
            _sdoOrdinate = SdoOrdinates.Null;
            _sdoPoint = SdoPoint.Null;
        }
    
        public SdoGeometry(SdoGeometry obj)
        {
            if (obj != null && this != obj)
            {
                SdoGType = obj.SdoGType;
                SdoSrid = obj.SdoSrid;
                SdoPoint = (SdoPoint)obj.SdoPoint.Clone();
                SdoElemInfo = (SdoElemInfo)obj.SdoElemInfo.Clone();
                SdoOrdinates = (SdoOrdinates)obj.SdoOrdinates.Clone();
            }
        }
    
        public SdoGeometry(
            int gType,
            int srid,
            SdoPoint point,
            SdoElemInfo elemInfo,
            SdoOrdinates ordinate)
        {
            SdoGType = gType;
            SdoSrid = srid;
            SdoPoint = (SdoPoint)point.Clone();
            SdoElemInfo = (SdoElemInfo)elemInfo.Clone();
            SdoOrdinates = (SdoOrdinates)ordinate.Clone();
        }
        #endregion
    
        #region ICloneable Members
        public object Clone()
        {
            return new SdoGeometry(this);
        }
        #endregion
    
        #region IOracleCustomType Members
        public void FromCustomObject(OracleConnection con, IntPtr pUdt)
        {
            if (!_sdoGTypeIsNull)
                OracleUdt.SetValue(con, pUdt, "SDO_GTYPE", SdoGType);
            if (!SdoOrdinates.IsNull)
                OracleUdt.SetValue(con, pUdt, "SDO_ORDINATES", SdoOrdinates);
            if (!SdoElemInfo.IsNull)
                OracleUdt.SetValue(con, pUdt, "SDO_ELEM_INFO", SdoElemInfo);
            if (!_sdoSridIsNull)
                OracleUdt.SetValue(con, pUdt, "SDO_SRID", SdoSrid);
            else
                OracleUdt.SetValue(con, pUdt, "SDO_SRID", DBNull.Value);
            if (!SdoPoint.IsNull)
                OracleUdt.SetValue(con, pUdt, "SDO_POINT", SdoPoint);
        }
    
        public void ToCustomObject(OracleConnection con, IntPtr pUdt)
        {
            object sdoGType = OracleUdt.GetValue(con, pUdt, "SDO_GTYPE");
            _sdoGTypeIsNull = sdoGType == null || sdoGType is DBNull;
            if (!_sdoGTypeIsNull)
                SdoGType = (int)sdoGType;
            SdoOrdinates = 
                (SdoOrdinates)OracleUdt.GetValue(con, pUdt, "SDO_ORDINATES");
            SdoElemInfo = 
                (SdoElemInfo)OracleUdt.GetValue(con, pUdt, "SDO_ELEM_INFO");
            object sdoSrid = OracleUdt.GetValue(con, pUdt, "SDO_SRID");
            if (!(sdoSrid == null || sdoSrid is DBNull))
                SdoSrid = (int)sdoSrid;
            SdoPoint = (SdoPoint)OracleUdt.GetValue(con, pUdt, "SDO_POINT");
        }
        #endregion
    
        #region INullable Members
        public bool IsNull
        {
            get { return _sdoGTypeIsNull; }
        }
        #endregion
    
        #region IOracleCustomTypeFactory Members
        public IOracleCustomType CreateObject()
        {
            return new SdoGeometry();
        }
        #endregion
    }
