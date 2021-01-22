    delegate bool Predicate (string s, params [] string terminators);
    bool HasAll(string s, params string [] terminators) {
        foreach (var t in terminators) {
           if (!s.contains(t)) return false;
        }
        return true;
    }
    bool HasAny(string s, params string [] terminators) {
        foreach (var t in terminators) {
            if (s.contains(t)) return true;
        }
        return false;
    }
    // Just looking now, I could also pass in a bool to switch between the two and remove one of these functions. But this is fairly clear
    string ReadData(TcpClient sock, Function predicate, params [] string terminators) {
        var sb = new StringBuilder();
        do
        {  
            var numBytesRead = s.GetStream().Read(byteBuff, 0, byteBuff.Length);
            sb.AppendFormat("{0}", Encoding.ASCII.GetString(byteBuff, 0, numBytesRead));
        } while (s.GetStream().DataAvailable && !predicate(sb.ToString(), terminators);
        return sb.ToString();
    }
