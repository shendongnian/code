    public class OrderRepository : Repository
    {
        public void Save(Order order)
    	{
    		if(order.IsDirty)
    		{
                        //sets up connection if required, command and sql
    			ICommand command = BuildCommandForSave(order);	
    			command.Execute();
    			OrderLineRepository orderLineRepo = GetOrderLineRepo();
    			foreach(OrderLine line in order.OrderLines)
    			{
    				orderLineRepo.Save(line);
    			}
    		}
    	}
    }
