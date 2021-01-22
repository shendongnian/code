        public IEnumerable<GeoAreaIdAndCode> ReadAllGssCodes()
        {
            var query = "select GeoAreaID,Code from GeoAreaAlternativeCode where AlternativeCodeType=" + (int)GeoAreaAlternativeCodeType.GssCode;
            var result = Owner.Session.CreateSQLQuery(query)
                                    .AddScalar("GeoAreaID",NHibernateUtil.Int32)
                                    .AddScalar("Code",NHibernateUtil.String)
                                    .SetResultTransformer(Transformers.AliasToBean(typeof (GeoAreaIdAndCode)))
                                    .List<GeoAreaIdAndCode>();
            return result;
        }
        public class GeoAreaIdAndCode
        {
            public int GeoAreaID { get; set; }
            public string Code { get; set; }
        }
