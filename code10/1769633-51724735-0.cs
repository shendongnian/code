    var root = new Rootobject
    	{
    		Companies = new Company[] {
    			new Company
    		{
    			ORG_NAME = "Co",
    			Salesareas = new SalesArea[]{
    			new SalesArea {
    				OBJ_NAME = "Sa",
    				AREA_CTYPE = "SaAr",
    			}
    		},
    			Nodes = new Node[] {
    			new Node {
    				OBJ_NAME = "No",
    				BUILDING = "NoBu"
    			}
    		},
    			Ethernetareas = new EthernetArea[] {
    			new EthernetArea {
    				OBJ_NAME = "Et",
    				AREA_CTYPE = "EtAr",
    				Products = new Product[] {
    					new Product {
    						BANDWIDTH_A = "ProA",
    						CONNECTION_TYPE = "ProCon"
    					}
    				}
    			}
    		}
    		},
    		new Company
    		{
    			ORG_NAME = "Co2",
    			Salesareas = new SalesArea[]{
    			new SalesArea {
    				OBJ_NAME = "Sa2",
    				AREA_CTYPE = "SaAr2",
    			}
    		},
    			Nodes = new Node[] {
    			new Node {
    				OBJ_NAME = "No2",
    				BUILDING = "NoBu2"
    			}
    		},
    			Ethernetareas = new EthernetArea[] {
    			new EthernetArea {
    				OBJ_NAME = "Et2",
    				AREA_CTYPE = "EtAr2",
    				Products = new Product[] {
    					new Product {
    						BANDWIDTH_A = "ProA2",
    						CONNECTION_TYPE = "ProCon2"
    					},
    					new Product {
    						BANDWIDTH_A = "ProA3",
    						CONNECTION_TYPE = "ProCon3"
    					}
    				}
    			}
    		}
    		}
    	}
    	};
    
    	var sas = root.Companies.SelectMany(x => x.Salesareas.Select(y => new { Company = x.ORG_NAME, SalesName = y.OBJ_NAME, SalesAreaType = y.AREA_CTYPE }));
    	var nodes = root.Companies.SelectMany(x => x.Nodes.Select(y => new { Company = x.ORG_NAME, NodesName = y.OBJ_NAME, NodeBuilding = y.BUILDING }));
    	var ethes = root.Companies.SelectMany(x => x.Ethernetareas.SelectMany(y => y.Products .Select(z => new { Company = x.ORG_NAME, EthernetName = y.OBJ_NAME, EthernetArea = y.AREA_CTYPE, BandwithA = z.BANDWIDTH_A, ConnnectionType = z.CONNECTION_TYPE })));
    	
    	sas.Join(nodes, x => x.Company, y => y.Company, (x, y) => new {x.Company, x.SalesName, x.SalesAreaType, y.NodesName, y.NodeBuilding})
    		.Join(ethes, x => x.Company, y => y.Company, (x, y) => new {x.Company, x.SalesName, x.SalesAreaType, x.NodesName, x.NodeBuilding, y.EthernetName, y.EthernetArea, y.BandwithA, y.ConnnectionType})
    		.Dump();
