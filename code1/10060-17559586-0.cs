    //Pass in your two datatables into your method
            //build the queries based on id.
            var qry1 = datatable1.AsEnumerable().Select(a => new { ID = a["ID"].ToString() });
            var qry2 = datatable2.AsEnumerable().Select(b => new { ID = b["ID"].ToString() });
            //detect row deletes - a row is in datatable1 except missing from datatable2
            var exceptAB = qry1.Except(qry2);
            //detect row inserts - a row is in datatable2 except missing from datatable1
            var exceptAB2 = qry2.Except(qry1);
