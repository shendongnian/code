    using System.Linq;
    //...
    //... code removed for brevity 
    var list = json.Deserialize<SearchList>(resString);
    var data = list.weather.Select(item => new {
        lon = list.coord.lon,
        lat = list.coord.lat,
        id = item.id,
        main = item.main,
        description = item.description,
        icon = item.icon
    });
    GridView1.DataSource = data;
    GridView1.DataBind();
    //... code removed for brevity
