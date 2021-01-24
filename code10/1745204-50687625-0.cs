    syntax = "proto3";
    
    service StackOverflowService {
      rpc GetAnswer(Question) returns (Answer);
    }
    
    message Question {
      string text = 1;
      string user = 2;
      repeated string tags = 3;
    }
    
    message Answer {
      string text = 1;
      string user = 2;
    }
