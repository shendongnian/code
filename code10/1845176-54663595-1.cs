public class DateTimeModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        if (context.Metadata.ModelType == typeof(DateTime))     // not typeof(Time)
        {
            return new BinderTypeModelBinder(typeof(DateTime));  
        }
        return null;
    }
}
Thus it **falls back to the default model binder for application/json**. The default json model binder uses `Newtonsoft.Json` under the hood and will simply deserialize the hole payload as an instance of `Time`. As a result, your `DateTimeModelBinder` is not invoked.
**2. Quick Fix**
One approach is to use `application/x-www-form-urlencoded` (avoid using the `application/json`)
Remove the `[FromBody]` attribute:
[HttpPost("/test2")]
public IActionResult test2(Time time)
{
    return Ok(time);
}
and send the payload in the format of `application/x-www-form-urlencoded`
POST https://localhost:5001/test2
Content-Type: application/x-www-form-urlencoded
validFrom=2018-01-01&validTo=2018-02-02
It should work now.
**3. Working with JSON**
Create a custom converter as below :
    public class CustomDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
             return true;
        }
        public static string[] _formats = new string[] { 
            "yyyyMMdd", "yyyy-MM-dd", "yyyy/MM/dd"
            , "yyyyMMddHHmm", "yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm"
            , "yyyyMMddHHmmss", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss"
        };
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dt= reader.Value;
            if (DateTime.TryParseExact(dt as string, _formats, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime dateTime)) 
                return dateTime;
            else 
                return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value as string);
        }
    }
I simply copy your code to format date. 
Change your Model as below :
    public class Time
    {
        [ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime? validFrom { get; set; }
        [ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime? validTo { get; set; }
    }
And now you can receive the time using `[FromBody]`
        [HttpPost("/test")]
        public IActionResult test([FromBody]Time time)
        {
            return Ok(time);
        }
