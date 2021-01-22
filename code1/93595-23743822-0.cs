            if (!IsPostBack)
            {
                if (bi == false)
                {
                    bi = true;
                    Response.Redirect("MainPage.aspx?id=null");
                    
                }
                else if (bi)
                {
                    string s = Request.QueryString["id"].ToString();
                    if (s != "null")
                    {
                        switch (s)
                        {
                            case "News":
                                {
                                    ProjectsManagment.Controls.AllNews n = new Controls.AllNews();
                                    MainContentsAsp.Controls.Add(n);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
        }
