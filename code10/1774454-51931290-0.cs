        .Field(new Field("UserProject.IdProject")
            .Options(new Options()
                .Table("View_User_Project")
                .Value("IdProject")
                .Label("Name")
                .Where((q) =>
                    {
                        q.Where("View_User_Project.IdUser", idUser);
                    }
                )
            )
            .Validator(Validation.NotEmpty())
        )
