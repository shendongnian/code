    public abstract class BIWebServiceResult<T>
        {
            public T Data;
    
            public delegate void StringToStatusCode(string Input);
    
            public abstract void SetData(string Input, StringToStatusCode StringToError);
        }
    
    
        public class StringBIServiceResult : BIWebServiceResult<string[]>
        {
            public override void SetData(string Input, StringToStatusCode StringToError)
            {
    
                    Data = new string[1];
                    Data[0] = Input;
            }
    
            private bool DetectBool(string Compare)
            {
                return Compare == "true";
            }
        }
