    using System;
    using System.Web.DynamicData;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    [MetadataType(typeof(UserInfoMetaData))]
    public partial class UserInfo
    {
   
    }
    public class UserInfoMetaData
    {
        [Required()]
        public object FirstName;
    }
