    NHibernateSession.Init(
                    webSessionStorage,
                    new string[] { Server.MapPath("~/bin/Assembly.dll") },
                    new AutoPersistenceModelGenerator().Generate(),
                    Server.MapPath("~/NHibernate.config"), Server.MapPath("~/nhv.config"));
 
