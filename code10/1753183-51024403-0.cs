      ...
    } catch(ApiException ae) {
      Console.WriteLine(ae.Message);
    } catch(Exception e) {
      Console.WriteLine("Exception Type:" + e.GetType().FullName);
      Console.WriteLine(e.Message);
    }
