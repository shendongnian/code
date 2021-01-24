    public Advert GetById(int id) {
        var connection = unitOfWork.Connection;
        String sql = 
        @"select * from Advert AS A
        inner join Member AS M on A.Creator = M.ID 
        where A.ID = @aid";
        var data connection.Query<Advert, Member, Advert>(
            sql, 
            (advert, member) => { advert.Owner = member; return advert; }, 
            new { aid = id }
        );
        return data.Single();
    }
    
