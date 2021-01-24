    public void Map(){
        var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<Object, Object>().ConvertUsing<XmlPropertyConvert>();
        cfg.CreateMap<UglyXmlSoapObject, Poco>();
    }
    public class XmlPropertyConverter : ITypeConverter<Object,Object>{
        
    public object Convert(object source, object destination, ResolutionContext context) {
        return GetValueObject(source)
    }
    private Object GetValueObject(Object member){
        var type = member.GetType();
        if (type.Name.ToLower().EndsWith("typeshape")){
        
        var property = type.GetProperties().SingleOrDefault(x => x.Name == "Value");
            if (property != null){
                var value = property.GetValue(member);
                return value;
            }
        }
 
        return member;
    }
    
    }
