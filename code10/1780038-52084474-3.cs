    public ActionResult GetEmployees()
    {
        try
        {
            int proveedor = Convert.ToInt32(Session["IdProveedor"]);
    
            DataSet ConsultaGrid = new DataSet();
            ConsultasProveedores ConsultaFacturas = new ConsultasProveedores();
            ConsultaGrid = ConsultaFacturas.ConsultaGen(Convert.ToString(proveedor));
    
            List<Proveedor> list = new List<Proveedor>();
            list.Add(new Proveedor {
               nFacturaProveedoresID = (int)ConsultaGrid.Tables[0].Rows[0]["nFacturaProveedoresID"],
               nSiniestroid = (int)ConsultaGrid.Tables[0].Rows[0]["nSiniestroid"],
               //rest of fields
            });
    
    
            return Json(new
            {
                data = list
            }, JsonRequestBehavior.AllowGet);
            }
        }
        catch (Exception ex)
        {
            return View("Login");
        }            
    }
