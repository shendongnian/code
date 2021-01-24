    function AddToCart() {
            var url = "@Url.Action("AddToCart", "Cart")";
            var idinput = $("#idinput").val();
            var amount = $("#amount").val();
            var rate = {
                idinput: idinput,
                amount: amount
            };
            rate = JSON.stringify(rate);
            $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=iso-8859-1",
            data: rate
          });
        }
    public ActionResult AddToCart(Data Data)
    {
       return Json("", JsonRequestBehavior.AllowGet);
    }
    public class Data
        {
            public int idinput { get; set; }
            public int amount { get; set; }
        }
