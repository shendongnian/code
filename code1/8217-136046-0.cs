            {
                WebId = Guid.Empty;
                WebId = new Guid(queryString["web"]);
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }
