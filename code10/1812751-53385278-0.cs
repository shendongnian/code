    public class Test
    {
        public JRaw Data { get; set; }
    }
    var testObj = new Test() {
        Data = new JRaw("{\"aws-s3-storage\":{\"bucket\":\"flight-gateway-test\",\"subfolder\":\"\",\"access-key\":\"AKIAJ6EPASSWORDV6TLPYV\",\"secret-key\":\"eklmmlevkqfvcuPASSWORDtpmam\",\"id\":28716,\"name\":\"S3 AWS East\"}}")
    };
    var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(testObj);
