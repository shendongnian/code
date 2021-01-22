    public static IEnumerable<IEnumerable<T>> Segment<T>(IEnumerable<T> sequence, Func<T, T, int, bool> newSegmentIdentifier) 
         { 
             var index = -1; 
             using (var iter = sequence.GetEnumerator()) 
             { 
                 var segment = new List<T>(); 
                 var prevItem = default(T); 
  
                 // ensure that the first item is always part 
                 // of the first segment. This is an intentional 
                 // behavior. Segmentation always begins with 
                 // the second element in the sequence. 
                 if (iter.MoveNext()) 
                 { 
                     ++index; 
                     segment.Add(iter.Current); 
                     prevItem = iter.Current; 
                 } 
  
                 while (iter.MoveNext()) 
                 { 
                     ++index; 
                     // check if the item represents the start of a new segment 
                     var isNewSegment = newSegmentIdentifier(iter.Current, prevItem, index); 
                     prevItem = iter.Current; 
      
                     if (!isNewSegment) 
                     { 
                         // if not a new segment, append and continue 
                         segment.Add(iter.Current); 
                         continue; 
                     } 
                     yield return segment; // yield the completed segment 
   
                     // start a new segment... 
                     segment = new List<T> { iter.Current }; 
                 } 
                 // handle the case of the sequence ending before new segment is detected 
                 if (segment.Count > 0) 
                     yield return segment; 
             } 
         } 
