    using System;
    using Newtonsoft.Json;
    namespace ConsoleApp8
    {
      public class TransHelper
      {
        public string Key { get; set; }
        public string Translation { get; set; }
      }
      public class MyBlob
      {
        public string Foo { get; set; }
        public TransHelper Bar { get; set; }
      }
      public class TransHelperConverter : JsonConverter<TransHelper>
      {
        public override TransHelper ReadJson( JsonReader reader, Type objectType, TransHelper existingValue, bool hasExistingValue, JsonSerializer serializer )
        {
          string key = null;
          string val = null;
          TransHelper instance = null;
          if ( reader.TokenType != JsonToken.Null )
          {
            if ( reader.TokenType != JsonToken.StartObject )
              throw new JsonReaderException( $"Unexpected Token: ${reader.TokenType}" );
            if ( !reader.Read() )
              throw new JsonReaderException( $"Unexpected EOF in Json" );
            if ( reader.TokenType != JsonToken.EndObject )
            {
              if ( reader.TokenType != JsonToken.PropertyName )
                throw new JsonReaderException( $"Unexpected Token: ${reader.TokenType}" );
              key = (string)reader.Value;
              if ( !reader.Read() )
                throw new JsonReaderException( $"Unexpected EOF in Json" );
              if ( reader.TokenType != JsonToken.String )
                throw new JsonReaderException( $"Unexpected Token: ${reader.TokenType}" );
              val = (string)reader.Value;
              if ( !reader.Read() )
                throw new JsonReaderException( "Unexpected EOF in Json" );
            }
            if ( reader.TokenType != JsonToken.EndObject )
              throw new JsonReaderException( $"Unexpected Token: ${reader.TokenType}" );
            instance = new TransHelper
            {
              Key = key,
              Translation = val,
            };
          }
          return instance;
        }
        public override void WriteJson( JsonWriter writer, TransHelper value, JsonSerializer serializer )
        {
          writer.WriteStartObject();
          writer.WritePropertyName( value.Key );
          writer.WriteValue( value.Translation );
          writer.WriteEndObject();
          return;
        }
      }
      class Program
      {
        static void Main( string[] argv )
        {
          string json = @"
    {
      ""Foo"": ""foo-value"",
      ""Bar"": {
        ""source"": ""translated-value""
      },
    }".Trim();
          TransHelperConverter converter = new TransHelperConverter();
          MyBlob deserialized = JsonConvert.DeserializeObject<MyBlob>( json, converter );
          string reserialized = JsonConvert.SerializeObject( deserialized, Formatting.Indented, converter );
          return;
        }
      }
    }
