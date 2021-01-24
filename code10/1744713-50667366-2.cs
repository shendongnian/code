      tblComents coment = new tblComents()
            {
                Date = DateComent.Value,
                Coment = TxtComent.Text.Trim()
            };
                tblProject project = ctx.tblProject(x=> x.Id == someid); // find the project you want
                if(project != null) project.tblComents.Add(coment);
    ctx.SaveChanges();
