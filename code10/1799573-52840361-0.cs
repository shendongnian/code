    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main (string[] args)
            {
                var text = @"public void GetEntities(List<PublisherBO> _publishers, WebResourceBO _webResourceBO, SqlBO _sqlBO) {
    
                                    List<EntityBO> entities = new List<EntityBO>();
    
                                        List<EntityMetadata> results = entityDAO.GetAllEntities();
                                        EntitiesMetadata = results;
                                        entities = ConvertEntities(results);
    
                                    Data = entities;
                                }
    
                            public void ResetConnection() {
                                sqlOpen = false;
                                dynamicsOpen = false;
    
                                if (Service != null) {
    
                                    if (Service.OrganizationWebProxyClient != null)
                                        Service.OrganizationWebProxyClient.Close();
    
                                    Service.Dispose();
                                }
                            }";
                var matches = Regex.Matches(text, "(.*?){(?:[^{}]+|{(?<n>)|}(?<-n>))+(?(n)(?!))*}");
                if (matches.Count > 0)
                {
    
                }
            }
        }
    }
