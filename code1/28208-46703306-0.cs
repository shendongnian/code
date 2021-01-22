    public ActionResult Paging(int? pageno,bool? fwd,bool? bwd)        
      {
            if(pageno!=null)
             {
               Session["currentpage"] = pageno;
             }
            using (HatronEntities DB = new HatronEntities())
            {
                if(fwd!=null && (bool)fwd)
                {
                    pageno = Convert.ToInt32(Session["currentpage"]) + 1;
                    Session["currentpage"] = pageno;
                }
                if (bwd != null && (bool)bwd)
                {
                    pageno = Convert.ToInt32(Session["currentpage"]) - 1;
                    Session["currentpage"] = pageno;
                }
                if (pageno==null)
                {
                    pageno = 1;
                }
                if(pageno<0)
                {
                    pageno = 1;
                }
                int total = DB.EmployeePromotion(0, 0, 0).Count();
                int  totalPage = (int)Math.Ceiling((double)total / 20);
                ViewBag.pages = totalPage;
                if (pageno > totalPage)
                {
                    pageno = totalPage;
                }
     return View
              (DB.EmployeePromotion(0,0,0)
       .Skip(GetSkip((int)pageno,20)).Take(20).ToList());     
      }
         
        }
        
        private static int GetSkip(int pageIndex, int take)
        {
            return (pageIndex - 1) * take;
        }
    @model IEnumerable<EmployeePromotion_Result>
    @{
      Layout = null;
    }
     <!DOCTYPE html>
     <html>
     <head>
        <meta name="viewport" content="width=device-width" />
        <title>Paging</title>
      </head>
      <body>
     <div> 
        <table border="1">
            @foreach (var itm in Model)
            {
     <tr>
       <td>@itm.District</td>
       <td>@itm.employee</td>
       <td>@itm.PromotionTo</td>
     </tr>
            }
        </table>
        <a href="@Url.Action("Paging", "Home",new { pageno=1 })">First  page</a> 
        <a href="@Url.Action("Paging", "Home", new { bwd =true })"><<</a> 
        @for(int itmp =1; itmp< Convert.ToInt32(ViewBag.pages)+1;itmp++)
       {
           <a href="@Url.Action("Paging", "Home",new { pageno=itmp   })">@itmp.ToString()</a>
       }
        <a href="@Url.Action("Paging", "Home", new { fwd = true })">>></a> 
        <a href="@Url.Action("Paging", "Home", new { pageno =                                                                               Convert.ToInt32(ViewBag.pages) })">Last page</a> 
    </div>
       </body>
      </html>
