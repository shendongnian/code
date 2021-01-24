    public async Task InsertCampigns()
            {
                var campaigns = new List<Campaign> {new Campaign(1, 1, "bar"), new Campaign(2, 2, "foo") };
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("exec [dbo].[spSaveCampaigns] @CampaignList", sqlConnection))
                    {
                        await sqlConnection.OpenAsync().ConfigureAwait(false);
    
                        using (var table = new DataTable())
                        {
                            table.Columns.Add("CampaignId", typeof(int));
                            table.Columns.Add("CookieId", typeof(int));
                            table.Columns.Add("Url", typeof(string));
    
                            foreach (var campaign in campaigns)
                                table.Rows.Add(campaign.CampaignId, campaign.CookieId, $"{campaign.Url}");
    
                            var parameters = new SqlParameter("@CampaignList", SqlDbType.Structured)
                                             {
                                                 TypeName = "dbo.CampaignList",
                                                 Value = table
                                             };
    
                            cmd.Parameters.Add(parameters);
                            await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                        }
                    }
                }
            }
