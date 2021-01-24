csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
internal class MultiFormatDateConverter : DateTimeConverterBase
{
    public IList<string> DateTimeFormats { get; set; } = new[] { "yyyy-MM-dd" };
    public DateTimeStyles DateTimeStyles { get; set; }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var val = IsNullableType(objectType);
        if (reader.TokenType == JsonToken.Null)
        {
            if (!val)
            {
                throw new JsonSerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Cannot convert null value to {0}.", objectType));
            }
        }
        Type underlyingObjectType = val ? Nullable.GetUnderlyingType(objectType)! : objectType;
        if (reader.TokenType == JsonToken.Date)
        {
            if (underlyingObjectType == typeof(DateTimeOffset))
            {
                if (!(reader.Value is DateTimeOffset))
                {
                    return new DateTimeOffset((DateTime)reader.Value);
                }
                return reader.Value;
            }
            if (reader.Value is DateTimeOffset)
            {
                return ((DateTimeOffset)reader.Value).DateTime;
            }
            return reader.Value;
        }
        if (reader.TokenType != JsonToken.String)
        {
            var errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                "Unexpected token parsing date. Expected String, got {0}.",
                reader.TokenType);
            throw new JsonSerializationException(errorMessage);
        }
        var dateString = (string)reader.Value;
        if (underlyingObjectType == typeof(DateTimeOffset))
        {
            foreach (var format in this.DateTimeFormats)
            {
                // adjust this as necessary to fit your needs
                if (DateTimeOffset.TryParseExact(dateString, format, CultureInfo.InvariantCulture, this.DateTimeStyles, out var date))
                {
                    return date;
                }
            }
        }
        if (underlyingObjectType == typeof(DateTime))
        {
            foreach (var format in this.DateTimeFormats)
            {
                // adjust this as necessary to fit your needs
                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, this.DateTimeStyles, out var date))
                {
                    return date;
                }
            }
        }
        throw new JsonException("Unable to parse \"" + dateString + "\" as a date.");
    }
    public override bool CanWrite
    {
        get { return false; }
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
    public static bool IsNullableType(Type t)
    {
        if (t.IsGenericTypeDefinition || t.IsGenericType)
        {
            return t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        return false;
    }
}
