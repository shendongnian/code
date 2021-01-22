    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Adhemar.Util {
    
        public struct EndMarkedItem<T> {
            public T Item { get; private set; }
            public int EndMark { get; private set; }
    
            public EndMarkedItem(T item, int endMark) : this() {
                Item = item;
                EndMark = endMark;
            }
        }
    
        public static class TailEnumerables {
    
            public static IEnumerable<T> ButLast<T>(this IEnumerable<T> ts) {
                return ts.ButLast(1);
            }
    
            public static IEnumerable<T> ButLast<T>(this IEnumerable<T> ts, int tailLength) {
                return ts.EndMark(tailLength).Where(te => te.EndMark == 0).Select(te => te.Item);
            }
    
            public static IEnumerable<EndMarkedItem<T>> EndMark<T>(this IEnumerable<T> ts) {
                return ts.EndMark(1);
            }
    
            public static IEnumerable<EndMarkedItem<T>> EndMark<T>(this IEnumerable<T> ts, int tailLength) {
                if (tailLength < 0) {
                    throw new ArgumentOutOfRangeException("tailLength");
                }
                else if (tailLength == 0) {
                    foreach (var t in ts) {
                        yield return new EndMarkedItem<T>(t, 0);
                    }
                }
                else {
                    var buffer = new T[tailLength];
                    var index = -buffer.tailLength;
                    foreach (var t in ts) {
                        if (index < 0) {
                            buffer[buffer.tailLength + index] = t;
                            index++;
                        }
                        else {
                            yield return new EndMarkedItem<T>(t, 0);
                            buffer[index] = t;
                            index++;
                            if (index == buffer.tailLength) {
                                index = 0;
                            }
                        }
                    }
                    if (index >= 0) {
                        for (var i = index; i < buffer.tailLength; i++) {
                            yield return new EndMarkedItem<T>(buffer[i], i - buffer.tailLength - index);
                        }
                        for (var j = 0; j < index; j++) {
                            yield return new EndMarkedItem<T>(buffer[j], j - index);
                        }
                    }
                    else {
                        for (var k = 0; k < buffer.tailLength + index; k++) {
                            yield return new EndMarkedItem<T>(buffer[k], k - buffer.tailLength - index);
                        }
                    }
                }    
            }
        }
    }
