      tblComents coment = new tblComents()
            {
                Date = DateComent.Value,
                Coment = TxtComent.Text.Trim()
            };
                tblProject project = new tblProject();
                project.Comments.Add(coment);
                ctx.tblProjects.Add(project);
    
                if(project != null) project.tblComents.Add(coment);
    ctx.SaveChanges();
