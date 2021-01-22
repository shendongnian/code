    SqlDevice device = GetDevice();
    
    return device.GetMultiple<Post>(
        "GetPosts",
        (s) => {
            s.Parameters.AddWithValue("@CreatedOn", DateTime.Today);
            
            return true;
        },
        (r, p) => {
            p.Title = r.Get<string>("Title");
    
            // Fill out post object
    
            return true;
        }
    );
