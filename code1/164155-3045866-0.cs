    public class SampleDataSerializer
    {
        public static void Deserialize<T>(out T data, Stream stm)
        {
            var xs = new XmlSerializer(typeof(T));
            data = (T)xs.Deserialize(stm);
        }
        public static void Serialize<T>(T data, Stream stm)
        {
            try
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(stm, data);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
