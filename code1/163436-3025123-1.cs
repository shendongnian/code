    public class BIWebServiceStrArrayResult : BIWebServiceResult<string[]>
    {
        public override void SetData(string Input, StringToStatusCode StringToError)
        {
            if (StringToError(Input) == 0)
            {
                Data = new string[1];
                Data[0] = Input;
            }
        }
    }
