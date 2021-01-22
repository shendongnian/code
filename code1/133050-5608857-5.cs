    using System.Reflection;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    
    namespace MyMappings
    {
        public class StringColumnLengthConvention : IPropertyConvention, IPropertyConventionAcceptance
        {
            public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria) { criteria.Expect(x => x.Type == typeof(string)).Expect(x => x.Length == 0); }
            public void Apply(IPropertyInstance instance)
            {
                int leng = 255;
    
                MemberInfo[] myMemberInfos = ((PropertyInstance)(instance)).EntityType.GetMember(instance.Name);
                if (myMemberInfos.Length > 0)
                {
                    object[] myCustomAttrs = myMemberInfos[0].GetCustomAttributes(false);
                    if (myCustomAttrs.Length > 0)
                    {
                        if (myCustomAttrs[0] is MyDomain.DBDecorations.StringLength)
                        {
                            leng = ((MyDomain.DBDecorations.StringLength)(myCustomAttrs[0])).Length;
                        }
                    }
                }
                instance.Length(leng);
            }
        }
    }
