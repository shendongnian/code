    public interface IData
    {
        bool Success { get; set; }
    }
    public class Response
    {
        public IData Data { get; set; }
    }
    public class UserData : IData
    {
        public bool Success { get; set; }
        public List<int> UpdatedIds { get; set; }
        public List<int> NotUpdatedIds { get; set; }
    }
    public class BranchData : IData
    {
        public bool Success { get; set; }
        public List<string> BranchIds { get; set; }
    }
    public class HowToUseIt
    {
        public Response CreateResponse()
        {
            Response myReponse = new Response
            {
                Data = new UserData
                {
                    Success = true,
                    UpdatedIds = new List<int>(),
                    NotUpdatedIds = new List<int>()
                }
            };
            return myReponse;
        }
        public void WhatKindOfDataDoIHave(Response response)
        {
            if (typeof(UserData) == response.Data.GetType())
            {
                //You have user data
            }
            else if (typeof(BranchData) == response.Data.GetType())
            {
                //You have branch data
            }
            else
            {
                //You have a problem!
            }
        }
        
    }
